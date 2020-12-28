import { __decorate } from "tslib";
import { Component } from '@angular/core';
let CheckoutComponent = class CheckoutComponent {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = "";
    }
    ngOnInit() {
        if (this.data.order.items.length === 0)
            this.router.navigate(['/']);
    }
    onCheckout() {
        this.data.checkout()
            .subscribe(success => {
            if (success) {
                this.router.navigate(['/']);
            }
        }, err => this.errorMessage = "Failed to save order");
    }
};
CheckoutComponent = __decorate([
    Component({
        selector: 'app-checkout',
        templateUrl: './checkout.component.html',
        styleUrls: ['./checkout.component.scss']
    })
], CheckoutComponent);
export { CheckoutComponent };
//# sourceMappingURL=checkout.component.js.map