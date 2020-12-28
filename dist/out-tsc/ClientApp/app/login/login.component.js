import { __decorate } from "tslib";
import { Component } from '@angular/core';
let LoginComponent = class LoginComponent {
    constructor(data, router) {
        this.data = data;
        this.router = router;
        this.errorMessage = '';
        this.creds = {
            username: '',
            password: ''
        };
    }
    ngOnInit() {
    }
    onLogin() {
        this.data.login(this.creds).subscribe(success => {
            if (success) {
                if (this.data.order.items.length === 0) {
                    this.router.navigate(["/"]);
                }
                else {
                    this.router.navigate(["checkout"]);
                }
            }
        }, err => this.errorMessage = 'Failed to login');
    }
};
LoginComponent = __decorate([
    Component({
        selector: 'app-login',
        templateUrl: './login.component.html',
        styleUrls: ['./login.component.scss']
    })
], LoginComponent);
export { LoginComponent };
//# sourceMappingURL=login.component.js.map