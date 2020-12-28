import { __decorate } from "tslib";
import { Component } from '@angular/core';
let ProductListComponent = class ProductListComponent {
    constructor(data) {
        this.data = data;
        this.products = [];
        this.products = data.products;
    }
    ngOnInit() {
        this.data.loadProducts()
            .subscribe(() => this.products = this.data.products);
    }
    addProduct(p) {
        this.data.addToOrder(p);
    }
};
ProductListComponent = __decorate([
    Component({
        selector: 'app-product-list',
        templateUrl: './product-list.component.html',
        styleUrls: ['./product-list.component.scss']
    })
], ProductListComponent);
export { ProductListComponent };
//# sourceMappingURL=product-list.component.js.map