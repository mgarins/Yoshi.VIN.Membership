import { Component, Inject, ViewEncapsulation, OnInit , EventEmitter, Input, Output} from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../../models/member';
import  { DataTableModule }  from  "angular2-datatable";

@Component({
    selector: 'member-list',
    templateUrl: './memberlist.component.html'
})

export class MemberListComponent  {
    @Input()
    memberList: Member[];

    @Output()
    remove: EventEmitter<Member> = new EventEmitter();
    edit: EventEmitter<Member> = new EventEmitter();

    constructor() {

    }

    removeMember(member: Member) {
        this.remove.emit(member);
    }

    editMember(member: Member) {
        this.edit.emit(member);
    }
}