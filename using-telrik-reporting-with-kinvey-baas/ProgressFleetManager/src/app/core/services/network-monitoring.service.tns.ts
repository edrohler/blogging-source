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
import { Injectable, NgZone } from "@angular/core";
import { BehaviorSubject, Observable } from "rxjs";
import * as Connectivity from "tns-core-modules/connectivity";

@Injectable()
export class NetworkMonitoringService {
    public isOnline: boolean;
    private subject: BehaviorSubject<boolean>;

    constructor(private zone: NgZone) {
        this.init();
    }

    get connectionObservable(): Observable<boolean> {
        return this.subject.asObservable();
    }

    private init(): void {
        this.isOnline = this.getOnlineStatus(Connectivity.getConnectionType());
        this.subject = new BehaviorSubject(this.isOnline);
        Connectivity.startMonitoring(connectionType => {
            this.isOnline = this.getOnlineStatus(connectionType);
            this.subject.next(this.isOnline);
        });
    }

    private getOnlineStatus(connectionType: number): boolean {
        return connectionType === Connectivity.connectionType.wifi
            || connectionType === Connectivity.connectionType.mobile;
    }
}