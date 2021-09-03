import { Component, AfterViewInit, ViewChild} from '@angular/core';
import { reportFiles } from 'src/app/common/files';
import { TelerikReportViewerComponent } from '@progress/telerik-angular-report-viewer';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html'
})
export class ReportsComponent implements AfterViewInit {
  @ViewChild('viewer1', { static: false }) viewer: TelerikReportViewerComponent;
  
  public selectedReport = "Dashboard.trdp";
  public reportFiles: string[] = reportFiles;

  title = "Report Viewer";

  viewerContainerStyle = {
      position: 'absolute',
      left: '5px',
      right: '5px',
      top: '200px',
      bottom: '5px',
      overflow: 'hidden',
      clear: 'both',
      ['font-family']: 'ms sans serif'
  };

  constructor() {

  }

  ngAfterViewInit() {
    var rs = {
      report: this.selectedReport
    };

    this.viewer.setReportSource(rs);
  }

  public selectionChange(value: any):void {
    var rs = {
      report: value
    };

    this.viewer.setReportSource(rs);
  }
}
