
export interface IProduct {
    id: number;
    sku: string;
    name: string;
    price: number;
    attribute: {
        fantastic: {
            name: string;
            type: number;
            value: boolean;
        },
        rating: {
            name: string;
            type: number;
            value: number;
        }
    };
}

export interface IPagedResponse<T> {
    data: T[];
    total: number;
    page: number;
}
