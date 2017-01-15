import { Injectable } from '@angular/core';
import { Http, Response, Headers } from '@angular/http';
import { Observable } from 'rxjs/Rx';
import { IProduct, IPagedResponse } from './product';

@Injectable()
export class ProductsService {

    private baseUrl: string = 'http://localhost:8002/api';

    constructor(private http: Http) { }

    getAll(): Observable<IProduct[]> {
        let products$ = this.http
            .get(`${this.baseUrl}/products`, { headers: this.getHeaders() })
            .map(mapProducts)
            .catch(handleError);
        return products$;
    }

    getAllPaged(pageIndex: number, pageSize: number): Observable<IPagedResponse<IProduct>> {
        let result$ = this.http
            .get(`${this.baseUrl}/products/${pageIndex}/${pageSize}`, { headers: this.getHeaders() })
            .map(mapPagedResponse)
            .catch(handleError);
        return result$;
    }

    get(id: number): Observable<IProduct> {
        let product$ = this.http
            .get(`${this.baseUrl}/products/${id}`, { headers: this.getHeaders() })
            .map(mapProduct);
        return product$;
    }

    save(product: IProduct): Observable<Response> {
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

function mapPagedResponse(res: Response): IPagedResponse<IProduct> {
    let pagedRes = <IPagedResponse<IProduct>>({
        data: res.json().data,
        total: res.json().total,
        page: res.json().page,
    });
    console.log('service - total count:', pagedRes.total);
    console.log('service - page index:', pagedRes.page);
    return pagedRes;
}

function mapProducts(response: Response): IProduct[] {
    // uncomment to simulate error:
    // throw new Error('ups! Force choke!');

    // The response of the API has a results
    // property with the actual results
    return response.json().map(toProduct);
    // return response.json().data.map(toProduct);
}

function toProduct(res: any): IProduct {
    let product = <IProduct>({
        id: extractId(res),
        name: res.name,
        price: res.price,
    });
    console.log('Parsed Product:', product);
    return product;
}

function extractId(productData: any) {
    let extractedId = productData.id;
    return parseInt(extractedId, 10);
}

function mapProduct(response: Response): IProduct {
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
