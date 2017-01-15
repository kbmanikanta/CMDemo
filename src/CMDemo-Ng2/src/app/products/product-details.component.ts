import { Component, OnInit, OnDestroy } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { Response } from '@angular/http';

import { IProduct } from './product';
import { ProductsService } from './products.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})

export class ProductDetailsComponent implements OnInit, OnDestroy {
  product: IProduct;
  sub: any;
  price: number;
  attribute: any;

  constructor(private productsService: ProductsService,
    private route: ActivatedRoute,
    private router: Router) { }

  ngOnInit() {
    this.sub = this.route.params.subscribe(params => {
      let id = Number.parseInt(params['id']);
      console.log('getting product with id: ', id);
      this.productsService
        .get(id)
        .subscribe(p => this.product = p);
    });
  }

  ngOnDestroy() {
    this.sub.unsubscribe();
  }

  gotoProductsList() {
    let link = ['/products'];
    this.router.navigate(link);
  }

  saveProductDetails() {
    this.productsService
      .save(this.product)
      .subscribe((r: Response) => { console.log('success'); });
  }
}
