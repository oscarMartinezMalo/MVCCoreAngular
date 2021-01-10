import { __decorate } from "tslib";
import { Component } from '@angular/core';
let CartComponent = class CartComponent {
    constructor(data, router) {
        this.data = data;
        this.router = router;
    }
    ngOnInit() {
    }
    OnCheckout() {
        if (this.data.loginRequired) {
            this.router.navigate(["login"]);
        }
        else {
            this.router.navigate(["checkout"]);
        }
    }
};
CartComponent = __decorate([
    Component({
        selector: 'app-cart',
        templateUrl: './cart.component.html',
        styleUrls: ['./cart.component.scss']
    })
], CartComponent);
export { CartComponent };
//# sourceMappingURL=cart.component.js.map