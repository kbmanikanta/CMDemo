import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { Ng2PaginationModule } from 'ng2-pagination';

import { AppRouting } from './app.routes';
import { AppComponent } from './app.component';
import { ProductsService } from './products/products.service';
import { ProductsListComponent } from './products/products-list.component';
import { ProductDetailsComponent } from './products/product-details.component';

@NgModule({
  declarations: [
    AppComponent,
    ProductsListComponent,
    ProductDetailsComponent,
  ],
  imports: [
    BrowserModule,
    Ng2PaginationModule,
    AppRouting,
    FormsModule,
    HttpModule,
  ],
  bootstrap: [AppComponent],
  providers: [],
})

export class AppModule { }
