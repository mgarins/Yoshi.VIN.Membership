import { Component, Inject, ViewEncapsulation, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Http, JsonpModule } from '@angular/http';
import { Member } from '../../models/member';

import { MemberService } from '../../services/member.service';
import { NgbModal, ModalDismissReasons, NgbModalRef } from '@ng-bootstrap/ng-bootstrap';

import { DataTableModule } from "angular2-datatable";
import { DatePipe } from '@angular/common';

@Component({
    selector: 'membership-app',
    templateUrl: './membership.component.html',
    providers: [MemberService, NgbModal]
})

export class MembershipModule implements OnInit {

    memberList: Member[];

    public ngOnInit() {
        this.memberService
            .getMembers()
            .subscribe(
            (members) => {
                this.memberList = members;
                console.log(this.memberList.length);
            }
            );
    }

    constructor(private memberService: MemberService, private modalService: NgbModal) { }
    addMember(editDlg: any)
    {
        console.log('addMember: ');
        // throw add new UI
    }

    doAddMember(member: Member) {
        console.log('doAddMember: ' + member.id);
        this.memberService
            .createMember(member)
            .subscribe(
            (newMember) => {
                this.memberList = this.memberList.concat(newMember);
            }
            );
    }

    updateMember(member: Member, editDlg: any)
    {
        console.log('updateMember: ' + member.id);

    }

    doUpdate(member: Member) {
        console.log('doUpdate: ' + member.id);

        this.memberService
            .updateMember(member)
            .subscribe(
            (updatedMember) => {
                member = updatedMember;
            }
            );
    }

    deleteMember(member: Member, content: any) {
        console.log('deleteMember: ' + member.id);

        this.modalService.open(content, { container: 'membership-app' }).result.then((result) => {
            console.log("Confirm choice: " + result);
            if (result == "OK") {
                this.doDeleteMember(member);
            }
        }, (reason) => {
            console.log("Dismissed");
        });

    }

    doDeleteMember(member: Member) {
        console.log('doDeleteMember: ' + member.id);
        this.memberService
            .deleteMember(member.id)
            .subscribe(
            (isRemoved) => {
                this.memberList = this.memberList.filter((m) => m.id !== member.id);
            }
            );
    }
}
