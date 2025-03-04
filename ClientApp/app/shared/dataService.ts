﻿import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { map } from 'rxjs/operators';
import { Product } from '../shared/product';
import { Observable } from 'rxjs';
import { Order, OrderItem } from './order';

@Injectable()
export class DataService {

    private token: string = "";
    private tokenExpiration: Date;

    constructor(private http: HttpClient) { }

    public products: Product[] = [];
    public order: Order = new Order();

    loadProducts(): Observable<true> {
        return this.http.get('/api/product')
            .pipe(
                map((data: any[]) => {
                    this.products = data;
                    return true;
                })
            )
    }

    public get loginRequired(): boolean {
        return this.token.length === 0 || this.tokenExpiration > new Date();
    }

    public login(creds): Observable<boolean> {
        return this.http
            .post("/account/createtoken", creds).pipe(
            map((data: any) => {
                this.token = data.token;
                this.tokenExpiration = data.expiration;
                return true;
            }));
    }

    public addToOrder(newProduct: Product) {
        let item: OrderItem = this.order.items.find(i => i.productId === newProduct.id);

        if (item) {
            item.quantity++;
        } else {
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

    public checkout() {
        if (!this.order.orderNumber) {
            this.order.orderNumber = this.order.orderDate.getFullYear().toString() + this.order.orderDate.getTime().toString();
        }

        return this.http.post('/api/order', this.order, { headers: new HttpHeaders().set("Authorization", `Bearer ${this.token}`) }).pipe(
            map(response => {
                this.order = new Order();
                return true;
            }));
    }

    public getShippingPrice() {
        // Send Http request to calculate the shipping cost
        return 0;
    }
}