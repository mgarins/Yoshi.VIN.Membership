import { Component, Inject, ViewEncapsulation, OnInit, EventEmitter, Input, Output } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../../models/member';
import { MemberListComponent } from './memberlist.component';
import { MemberService } from '../../services/member.service';

@Component({
    selector: 'membership-app',
    templateUrl: './membership.component.html',
    providers: [MemberService]
})

export class MembershipApp implements OnInit {


    members: Member[];

    public ngOnInit() {
        this.memberService
            .getMembers()
            .subscribe(
            (members) => {
                this.members = members;
            }
            );
    }

    constructor(private memberService: MemberService) { }

    onAddMember(member :Member) {
        this.memberService
            .createMember(member)
            .subscribe(
            (newMember) => {
                this.members = this.members.concat(newMember);
            }
            );

    }

    onUpdateMember(member: Member) {
        this.memberService
            .updateMember(member)
            .subscribe(
            (updatedMember) => {
                member = updatedMember;
            }
            );
    }

    onRemoveMember(member: Member) {
        this.memberService
            .deleteMember(member.id)
            .subscribe(
            (_) => {
                this.members = this.members.filter((m) => m.id !== member.id);
            }
            );
    }
}