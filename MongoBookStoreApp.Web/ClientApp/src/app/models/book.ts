export class Book {
    id: string;
    name: string;
    description: string;
    isbn: string;
    price: number;
    authorName: string;
    addedOn: Date;
}

export class ErrorResponse {
    errors: string[];
    isSuccess: boolean;
}