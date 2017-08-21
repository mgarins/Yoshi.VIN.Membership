import { Inject, Injectable } from '@angular/core';
import { Http, Response } from '@angular/http';
import { Member } from '../models/member';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/observable/throw';

@Injectable()
export class MemberService {

    constructor(private http: Http,
        @Inject('API_URL') private apiUrl: string) { }

    public getMembers(): Observable<Member[]> {
        var url: string = this.apiUrl + 'api/Members';
        return this.http
            .get(url)
            .map(response => {
                const members = response.json();
                return members.map((member: Member) => new Member(member));
            })

    }

    public createMember(member: Member): Observable<Member> {
        var url: string = this.apiUrl + 'api/Members';

        return this.http
            .post(url, member)
            .map(response => {
                return new Member(response.json());
            })
            .catch(this.handleError);
    }

    public getMemberById(id: number): Observable<Member> {
        var url: string = this.apiUrl + 'api/Members/';

        return this.http
            .get(url + id)
            .map(response => {
                return new Member(response.json());
            })
            .catch(this.handleError);
    }

    public updateMember(member: Member): Observable<Member> {
        var url: string = this.apiUrl + 'api/Members/';
        return this.http
            .put(url + member.id, member)
            .map(response => {
                return new Member(response.json());
            })
            .catch(this.handleError);
    }

    public deleteMember(id: number): Observable<null> {
        var url: string = this.apiUrl + 'api/Members/';

        return this.http
            .delete(url + id)
            .map(response => null)
            .catch(this.handleError);
    }


    private handleError(error: Response | any) {
        console.error('MemberService::handlerError', error);
        return Observable.throw(error);
    }
}