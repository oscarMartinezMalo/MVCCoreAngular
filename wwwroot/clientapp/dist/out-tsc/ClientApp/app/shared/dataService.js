import { __decorate } from "tslib";
import { HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Order, OrderItem } from './order';
let DataService = class DataService {
    constructor(http) {
        this.http = http;
        this.token = "";
        this.products = [];
        this.order = new Order();
    }
    loadProducts() {
        return this.http.get('/api/product')
            .pipe(map((data) => {
            this.products = data;
            return true;
        }));
    }
    get loginRequired() {
        return this.token.length === 0 || this.tokenExpiration > new Date();
    }
    login(creds) {
        return this.http
            .post("/account/createtoken", creds).pipe(map((data) => {
            this.token = data.token;
            this.tokenExpiration = data.expiration;
            return true;
        }));
    }
    addToOrder(newProduct) {
        let item = this.order.items.find(i => i.productId === newProduct.id);
        if (item) {
            item.quantity++;
        }
        else {
            item = new OrderItem();
            item.productId = newProduct.id;
            item.ProductArtId = newProduct.artId;
            item.productArtist = newProduct.artist;
            item.productCategory = newProduct.category;
            item.productSize = newProduct.size;
            item.productTitle = newProduct.title;
            item.unitPrice = newProduct.price;
            item.quantity = 1;
            this.order.items.push(item);
        }
    }
    checkout() {
        if (!this.order.orderNumber) {
            this.order.orderNumber = this.order.orderDate.getFullYear().toString() + this.order.orderDate.getTime().toString();
        }
        return this.http.post('/api/order', this.order, { headers: new HttpHeaders().set("Authorization", `Bearer ${this.token}`) }).pipe(map(response => {
            this.order = new Order();
            return true;
        }));
    }
    getShippingPrice() {
        // Send Http request to calculate the shipping cost
        return 0;
    }
};
DataService = __decorate([
    Injectable()
], DataService);
export { DataService };
//# sourceMappingURL=dataService.js.map