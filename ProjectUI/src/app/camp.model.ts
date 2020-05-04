export interface Camp {
    campId: number
    name: string;
    description?: string; // Optional
    capacity: number;
    rate: number;
    image: string;
}

export interface Filter {
    Capacity: number;
    CheckInDate: string; 
    CheckOutDate: string
}

export interface CampAndFilter {
    Camp: Camp;
    Filter: Filter;
}

export interface Booking {
    CheckInDate: string;
    CheckOutDate: string;
    BillingAddress: string;
    State: string;
    Country: string;
    ZipCode: number;
    Phone: number;
    CampId: number;
    TotalAmount: number;
}