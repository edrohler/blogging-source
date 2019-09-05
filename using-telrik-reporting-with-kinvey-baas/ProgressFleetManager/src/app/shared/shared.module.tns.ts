//-------------------------------------------------------------------------
// <Auto-generated file - do not modify!>
//
// This code was generated automatically by Kinvey Studio.
//
// Changes to this file may cause undesired behavior and will be lost
// the next time the code regenerates.
//
// Find more information on https://devcenter.kinvey.com/guides/studio-extension-points.
//-------------------------------------------------------------------------
import { NgModule, NO_ERRORS_SCHEMA } from "@angular/core";
import { ReactiveFormsModule } from '@angular/forms'
import { NativeScriptCommonModule } from "nativescript-angular/common";

import { NativeScriptFormsModule } from "nativescript-angular/forms";
import { NativeScriptUIAutoCompleteTextViewModule } from "nativescript-ui-autocomplete/angular";
import { NativeScriptUICalendarModule } from "nativescript-ui-calendar/angular";
import { NativeScriptUIChartModule } from "nativescript-ui-chart/angular";
import { NativeScriptUIDataFormModule } from "nativescript-ui-dataform/angular";
import { NativeScriptUIGaugeModule } from "nativescript-ui-gauge/angular";
import { NativeScriptUIListViewModule } from "nativescript-ui-listview/angular";
import { NativeScriptUISideDrawerModule } from 'nativescript-ui-sidedrawer/angular';
import { NativeChatModule } from "@progress-nativechat/nativescript-nativechat/angular";
import { NativeScriptPickerModule } from "nativescript-picker/angular";
import { NativeScriptDateTimePickerModule } from "nativescript-datetimepicker/angular";

const pagerPlugin = [];

try {
    const { PagerModule } = require('nativescript-pager/angular');
    pagerPlugin.push(PagerModule);
} catch {
    console.log('Missing \'nativescript-pager\' plugin!')
}

import { HideNavBarDirective } from "@src/app/shared/directives/hide-nav-bar.directive";
import { ShowNavBarDirective } from "@src/app/shared/directives/show-nav-bar.directive";
import { ActionBarControllerDirective } from "@src/app/shared/directives/action-bar-controller.directive";
import { ChatComponent } from '@src/app/shared/components/mobile-chat/chat.component'
import { KSButtonComponent } from '@src/app/shared/components/mobile-button/button.component';
import { KSListViewComponent } from '@src/app/shared/components/mobile-list-view/list-view.component';
import { KSNavigationLabelComponent } from '@src/app/shared/components/mobile-navigation-label/navigation-label.component';
import { KSSearchBarComponent } from '@src/app/shared/components/mobile-search-bar/search-bar.component';
import { KSFormComponent} from "@src/app/shared/components/mobile-form/form.component"
import { KSTakePictureComponent } from '@src/app/shared/components/mobile-take-picture/take-picture.component'
import { KSFormButtonComponent } from '@src/app/shared/components/mobile-form-button/form-button.component';
import { KSMapbox } from '@src/app/shared/components/mobile-mapbox/mapbox.component'

import { config, transformConfig } from '@src/app/shared/shared.config';

const configMeta: NgModule = {
    providers: [
        ...config.providers
    ],
    declarations: [
        HideNavBarDirective,
        ShowNavBarDirective,
        ActionBarControllerDirective,
        ChatComponent,
        KSButtonComponent,
        KSListViewComponent,
        KSNavigationLabelComponent,
        KSSearchBarComponent,
        KSFormComponent,
        KSTakePictureComponent,
        KSFormButtonComponent,
        KSMapbox,
        ...config.declarations
    ],
    imports: [
        NativeScriptCommonModule,
        NativeScriptFormsModule,
        NativeScriptUIAutoCompleteTextViewModule,
        NativeScriptUICalendarModule,
        NativeScriptUIChartModule,
        NativeScriptUIDataFormModule,
        NativeScriptUIGaugeModule,
        NativeScriptUIListViewModule,
        NativeScriptUISideDrawerModule,
        NativeChatModule,
        ReactiveFormsModule,
        NativeScriptPickerModule,
        NativeScriptDateTimePickerModule,
        ...pagerPlugin,
        ...config.imports
    ],
    exports: [
        NativeScriptCommonModule,
        NativeScriptFormsModule,
        NativeScriptUIAutoCompleteTextViewModule,
        NativeScriptUICalendarModule,
        NativeScriptUIChartModule,
        NativeScriptUIDataFormModule,
        NativeScriptUIGaugeModule,
        NativeScriptUIListViewModule,
        NativeScriptUISideDrawerModule,
        ReactiveFormsModule,
        NativeScriptPickerModule,
        NativeScriptDateTimePickerModule,
        ...pagerPlugin,

        HideNavBarDirective,
        ShowNavBarDirective,
        ActionBarControllerDirective,
        ChatComponent,
        KSButtonComponent,
        KSListViewComponent,
        KSNavigationLabelComponent,
        KSSearchBarComponent,
        KSFormComponent,
        KSTakePictureComponent,
        KSFormButtonComponent,
        KSMapbox,
        ...config.exports
    ],
    entryComponents: [
        ...config.entryComponents
    ],
    bootstrap: [
        ...config.bootstrap
    ],
    schemas: [
        NO_ERRORS_SCHEMA,
        ...config.schemas
    ],
    id: config.id,
    jit: config.jit
};

transformConfig(configMeta);

@NgModule(configMeta)
export class SharedModule {}
