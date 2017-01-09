
export interface Product {
    id: number;
    sku: string;
    name: string;
    price: number;
    attribute: {
        fantastic: {
            value: boolean;
            type: number;
            name: string;
        },
        rating: {
            name: string;
            type: number;
            value: number;
        }
    };
}
