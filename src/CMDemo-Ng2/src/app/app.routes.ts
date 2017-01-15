import { RouterModule, Routes } from '@angular/router';

import { ProductsListComponent } from './products/products-list.component';
import { ProductDetailsComponent } from './products/product-details.component';

const routes: Routes = [
    // map '/products' to the product list component
    {
        path: 'products',
        component: ProductsListComponent
    },
    // map '/products/:id' to person details component
    {
        path: 'products/:id',
        component: ProductDetailsComponent
    },
    // map '/' to '/products' as our default route
    {
        path: '',
        redirectTo: '/products',
        pathMatch: 'full'
    },
];

export const AppRouting = RouterModule.forRoot(routes);
