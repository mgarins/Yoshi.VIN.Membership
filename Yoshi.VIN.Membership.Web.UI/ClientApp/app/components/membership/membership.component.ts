import { Component, Inject, ViewEncapsulation, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../../models/member';
import { MemberListComponent } from './memberlist.component';
import { MemberService } from '../../services/member.service';
import { NgbModal, ModalDismissReasons } from '@ng-bootstrap/ng-bootstrap';

@Component({
    selector: 'membership-app',
    templateUrl: './membership.component.html',
    providers: [MemberService]
})

export class MembershipApp implements OnInit {

    members: Member[];
    private selectedMember: Member;

    public ngOnInit() {
        this.memberService
            .getMembers()
            .subscribe(
            (members) => {
                this.members = members;
                console.log(members.length);
            }
            );
    }

    constructor(private memberService: MemberService, private modalService: NgbModal) { }

    onAddMember(member: Member) {
        this.memberService
            .createMember(member)
            .subscribe(
            (newMember) => {
                this.members = this.members.concat(newMember);
            }
            );

    }

    onEditMember(member: Member) {
        alert('OnEdit: ' + member.id);
        // throw ui UI to edit
        //this.memberService
        //    .updateMember(member)
        //    .subscribe(
        //    (updatedMember) => {
        //        member = updatedMember;
        //    }
        //    );
    }

    onRemoveMember(member: Member) {

        //this.modalService.open(content).result.then((result) => {
        //    console.log("Confirm choice: " + result);
        //    if (result == "OK") {
        //        this.doDeletion(member);
        //    }
        //}, (reason) => {
        //    console.log("Dismissed");
        //});

    }

    doDeletion(member: Member) {
        this.memberService
            .deleteMember(member.id)
            .subscribe(
            (isRemoved) => {
                this.members = this.members.filter((m) => m.id !== member.id);
            }
            );
    }
}