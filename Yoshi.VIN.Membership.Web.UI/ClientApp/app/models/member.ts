export class Member
{
    id: number;
    userName: string;
    lastName: string;
    firstName: string;
    email: string;
    phone: string;
    dob: string;

    constructor(values: Object = {}) {
        Object.assign(this, values);
    }
}