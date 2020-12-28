import { Component, OnInit } from '@angular/core';
import { DataService } from '../shared/dataService';
import { Product } from '../shared/product';

@Component({
  selector: 'app-product-list',
  templateUrl: './product-list.component.html',
  styleUrls: ['./product-list.component.scss']
})
export class ProductListComponent implements OnInit {

    constructor(private data: DataService) {
        this.products = data.products;
    }

    products: Product[] = [];
    ngOnInit(): void {
        this.data.loadProducts()
            .subscribe(() => this.products = this.data.products);
    }

    addProduct(p: Product) {
        this.data.addToOrder(p);
    }

}
