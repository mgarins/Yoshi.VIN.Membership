import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { DataTableModule } from "angular2-datatable";

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { MembershipApp } from './components/membership/membership.component';
import { MemberListComponent } from './components/membership/memberlist.component';
import { ContactDetailsComponent } from './components/contactdetails/contactdetails.component';

import { PhoneFormatPipe } from './components/phonepipe/phone.pipe.module';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        MemberListComponent,
        MembershipApp,
        ContactDetailsComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        PhoneFormatPipe,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'member-list', component: MembershipApp },
            { path: '**', redirectTo: 'home' }
        ]),
        DataTableModule
    ]
})
export class AppModuleShared {
}
