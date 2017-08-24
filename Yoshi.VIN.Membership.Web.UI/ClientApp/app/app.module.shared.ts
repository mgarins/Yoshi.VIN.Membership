import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule, JsonpModule } from '@angular/http';
import { RouterModule } from '@angular/router';
import { DataTableModule } from "angular2-datatable";

// Angular Bootstrap stuff
import { NgbModule} from "@ng-bootstrap/ng-bootstrap";

// app components 
import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { MembershipModule } from './components/membership-alt/membership.component';
import { ContactDetailsComponent } from './components/contactdetails/contactdetails.component';

import { PhoneFormatPipe } from './components/phonepipe/phone.pipe.module';


@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        FetchDataComponent,
        MembershipModule,
        ContactDetailsComponent,
        HomeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        ReactiveFormsModule,
        JsonpModule,
        PhoneFormatPipe,
        NgbModule.forRoot(),
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'member-list', component: MembershipModule },
            { path: '**', redirectTo: 'home' }
        ]),
        DataTableModule
    ]
})
export class AppModuleShared {
}
