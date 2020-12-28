import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Router } from '@angular/router';

@Component({
  selector: 'app-checkout',
  templateUrl: './checkout.component.html',
  styleUrls: ['./checkout.component.scss']
})
export class CheckoutComponent implements OnInit {
    errorMessage: string = "";

    constructor(public data: DataService,
        private router: Router) { }

    ngOnInit(): void {
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

}
