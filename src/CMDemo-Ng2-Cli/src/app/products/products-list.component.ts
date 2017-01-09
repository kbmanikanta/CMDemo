import { Component, OnInit } from '@angular/core';
import { Product } from './product';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css']
})

export class ProductsListComponent implements OnInit {
  products: Product[] = [];
  errorMessage: string = '';
  isLoading: boolean = true;

  constructor(private productsService: ProductsService) { }

  ngOnInit() {
    this.productsService
      .getAll()
      .subscribe(
         /* happy path */ p => this.products = p,
         /* error path */ e => this.errorMessage = e,
         /* onComplete */() => this.isLoading = false);
  }
}
