import { Observable } from 'rxjs/Rx';
import { Component, OnInit } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { IProduct, IPagedResponse } from './product';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-products-list',
  templateUrl: './products-list.component.html',
  styleUrls: ['./products-list.component.css'],
})

export class ProductsListComponent implements OnInit {
  total: number;
  page: number = 1;
  pageSize: number = 20;
  products: IProduct[] = [];
  errorMessage: string = '';
  isLoading: boolean = true;

  constructor(
    private productsService: ProductsService
  ) { }

  ngOnInit() {
    // this.getAll();
    this.getPage(1);
  }

  getAll() {
    this.productsService
      .getAll()
      .subscribe(
         /* happy path */ p => this.products = p,
         /* error path */ e => this.errorMessage = e,
         /* onComplete */() => this.isLoading = false);
  }

  getPage(page: number) {
    this.productsService
      .getAllPaged(page, this.pageSize)
      .subscribe(
      res => {
        // if (res.error) {
        // } else {
        this.total = res.total;
        this.products = res.data;
        this.page = res.page;
        // }
      },
      e => this.errorMessage = e,
      () => this.isLoading = false);
  }
}

