import { Component, Inject, ViewEncapsulation, OnInit } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../../models/member';
import { MemberAddComponent } from '../memberadd/memberadd.component';
import { MemberService } from '../../services/member.service';

@Component({
    selector: 'member-list',
    templateUrl: './memberlist.component.html',
    providers: [MemberService]
})

export class MemberListComponent implements OnInit {
    public members: Member[];
    selectedMember: Member;

    constructor(private memberService: MemberService) { }

    public ngOnInit() {
        this.memberService
            .getMembers()
            .subscribe(
            (members) => {
                this.members = members;
            }
            );
    }

    onSelect(member: Member): void {
        this.selectedMember = member;
    }
}