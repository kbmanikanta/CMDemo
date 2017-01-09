import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { Product } from './product';

@Injectable()
export class ProductsService {

    private baseUrl: string = 'http://localhost:8002/api';

    constructor(private http: Http) {
    }

    getAll(): Observable<Product[]> {
        let products$ = this.http
            .get(`${this.baseUrl}/products`, { headers: this.getHeaders() })
            .map(mapProducts)
            .catch(handleError);
        return products$;
    }

    get(id: number): Observable<Product> {
        let product$ = this.http
            .get(`${this.baseUrl}/products/${id}`, { headers: this.getHeaders() })
            .map(mapProduct);
        return product$;
    }

    save(product: Product): Observable<Response> {
        // this won't actually work because the StarWars API doesn't
        // is read-only. But it would look like this:
        return this.http
            .put(`${this.baseUrl}/products/${product.id}`, JSON.stringify(product), { headers: this.getHeaders() });
    }

    private getHeaders() {
        let headers = new Headers();
        headers.append('Accept', 'application/json');
        return headers;
    }
}

function mapProducts(response: Response): Product[] {
    // uncomment to simulate error:
    // throw new Error('ups! Force choke!');

    // The response of the API has a results
    // property with the actual results
    return response.json().map(toProduct);
}

function toProduct(r: any): Product {
    let product = <Product>({
        id: extractId(r),
        name: r.name,
        price: r.price,
    });
    console.log('Parsed Product:', product);
    return product;
}

function extractId(productData: any) {
    let extractedId = productData.id;
    return parseInt(extractedId, 10);
}

function mapProduct(response: Response): Product {
    // toProduct looks just like in the previous example
    return toProduct(response.json());
}

// this could also be a private method of the component class
function handleError(error: any) {
    // log error
    // could be something more sofisticated
    let errorMsg = error.message || `Yikes! There was was a problem with our hyperdrive device and we couldn't retrieve your data!`
    console.error(errorMsg);

    // throw an application level error
    return Observable.throw(errorMsg);
}
