import { Component, Inject, ViewEncapsulation, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../../models/member';
import { DataTableModule } from "angular2-datatable";
import { DatePipe } from '@angular/common';


@Component({
    selector: 'member-list',
    templateUrl: './memberlist.component.html'
})

export class MemberListComponent {
    @Input()
    memberList: Member[];

    @Output()
    removeClicked: EventEmitter<Member> = new EventEmitter();
    editClicked: EventEmitter<Member> = new EventEmitter();

    constructor() {

    }

    removeMember(member: Member) {
        console.log('Remove Member Clicked ' + member.id);
        this.removeClicked.emit(member);
    }

    editMember(member: Member) {
        console.log('Edit Member Clicked ' + member.id);
        this.editClicked.emit(member);
    }
}