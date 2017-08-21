import { Component, Inject, Input } from '@angular/core';
import { Http } from '@angular/http';
import { Member } from '../../models/member';

@Component({
    selector: 'member-details',
    templateUrl: './memberadd.component.html'
})
export class MemberAddComponent {
    @Input() currentMember: Member;
}
