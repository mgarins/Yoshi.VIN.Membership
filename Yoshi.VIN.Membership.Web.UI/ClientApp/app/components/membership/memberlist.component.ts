import { Component, Inject, ViewEncapsulation, OnInit , EventEmitter, Input, Output} from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../../models/member';

@Component({
    selector: 'member-list',
    templateUrl: './memberlist.component.html'
})

export class MemberListComponent  {
    @Input()
    membersList: Member[];

    @Output()
    remove: EventEmitter<Member> = new EventEmitter();

    constructor() {

    }

    removeMember(member: Member) {
        this.remove.emit(member);
    }
}