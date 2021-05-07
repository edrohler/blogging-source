import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AppComponent } from './app.component';
import { MenuModule } from '@progress/kendo-angular-menu';
import { GridModule } from '@progress/kendo-angular-grid';
import { ChartsModule } from '@progress/kendo-angular-charts';
import { DropDownsModule } from '@progress/kendo-angular-dropdowns';
import { PopupModule } from '@progress/kendo-angular-popup';
import { InputsModule } from '@progress/kendo-angular-inputs';

import 'hammerjs';

import { HeaderComponent } from './components/header/header.component';
import { HomeComponent } from './components/home/home.component';
import { FooterComponent } from './components/footer/footer.component';
import { Blank1Component } from "./components/blank-1/blank-1.component";

const routes: Routes = [
    { path: '', redirectTo: 'home', pathMatch: 'full' },
    { path: 'home', component: HomeComponent },
    { path: 'blank-1', component: Blank1Component },
    { path: '**', redirectTo: 'home' }
];

@NgModule({
    declarations: [
        AppComponent,
        HeaderComponent,
        HomeComponent,
        Blank1Component,
        FooterComponent
    ],
    imports: [
      BrowserModule,
      ReactiveFormsModule,
      FormsModule,
      MenuModule,
      BrowserAnimationsModule,
      GridModule,
      ChartsModule,
      RouterModule.forRoot(routes),
      DropDownsModule, PopupModule, InputsModule
  ],
    bootstrap: [AppComponent]
})
export class AppModule { }
