import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'member-list',
    templateUrl: './memberlist.component.html'
})
export class MemberListComponent {
    public members: Member[];

    constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
        http.get(baseUrl + 'api/Members').subscribe(result => {
            this.members = result.json() as Member[];
        }, error => console.error(error));
    }
}

interface Member {
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    phone: number;
    dob: string; 
}