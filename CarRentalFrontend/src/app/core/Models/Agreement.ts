export interface Agreement {
    vehicleId: string,
    maker: string,
    model: string,
    rentalPrice: number,
    totalCost: number,
    startDate: string,
    endDate: string,
    name: string,
    email: string,
    phoneNumber: string,
    id?:string,
    status?:string
}