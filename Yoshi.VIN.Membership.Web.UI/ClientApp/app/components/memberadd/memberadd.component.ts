import { Component, Inject } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'member-add',
    templateUrl: './memberadd.component.html'
})
export class MemberAddComponent {
    public member: Member;

    //constructor(http: Http, @Inject('BASE_URL') baseUrl: string) {
    //    http.get(baseUrl + 'api/Members').subscribe(result => {
    //        this.members = result.json() as Member[];
    //    }, error => console.error(error));
    //}
}

interface Member {
    userName: string;
    firstName: string;
    lastName: string;
    email: string;
    phone: number;
    dob: string;
}