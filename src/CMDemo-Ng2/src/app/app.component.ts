import { Component } from '@angular/core';
import { ProductsService } from './products/products.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [ProductsService]
})

export class AppComponent {
  // title = 'app works!';
  title = 'CMDemo - Angular 2 works!';

  constructor(private productsService: ProductsService) { }
}
