import { __decorate } from "tslib";
import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShopComponent } from './shop/shop.component';
import { ProductListComponent } from './product-list/product-list.component';
import { DataService } from './shared/dataService';
import { HttpClientModule } from '@angular/common/http';
import { CartComponent } from './cart/cart.component';
import { CheckoutComponent } from './checkout/checkout.component';
import { LoginComponent } from './login/login.component';
import { FormsModule } from '@angular/forms';
let AppModule = class AppModule {
};
AppModule = __decorate([
    NgModule({
        declarations: [
            AppComponent,
            ShopComponent,
            ProductListComponent,
            CartComponent,
            CheckoutComponent,
            LoginComponent
        ],
        imports: [
            BrowserModule,
            HttpClientModule,
            AppRoutingModule,
            FormsModule
        ],
        providers: [DataService],
        bootstrap: [AppComponent]
    })
], AppModule);
export { AppModule };
//# sourceMappingURL=app.module.js.map