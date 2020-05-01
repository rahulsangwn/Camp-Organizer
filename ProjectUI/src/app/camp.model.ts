export interface Camp {
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