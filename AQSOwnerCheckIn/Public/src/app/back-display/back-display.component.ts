// import { BackDisplayComponent } from 'app-back-display.component';
import {SelectionModel} from '@angular/cdk/collections';
import {Component} from '@angular/core';
import {MatTableDataSource} from '@angular/material/table';

export interface PeriodicElement {
  name: string;
  petID: string;
}

/**
 * @title Table with selection
 */
@Component({
  selector: 'app-back-display',
  styleUrls: ['back-display.component.css'],
  templateUrl: 'back-display.component.html',
})
export class BackDisplayComponent {
  displayedColumns: string[] = ['name', 'petID', 'arrived', 'inspected', 'release'];
  dataSource = new MatTableDataSource<BackDisplayComponent>(this.data);
  selection = new SelectionModel<BackDisplayComponent>(true, []);

  /** Whether the number of selected elements matches the total number of rows. */
  isAllSelected() {
    const numSelected = this.selection.selected.length;
    const numRows = this.dataSource.data.length;
    return numSelected === numRows;
  }

  /** Selects all rows if they are not all selected; otherwise clear selection. */
  masterToggle() {
    this.isAllSelected() ?
        this.selection.clear() :
        this.dataSource.data.forEach(row => this.selection.select(row));
  }

  /** The label for the checkbox on the passed row */
  checkboxLabel(row?: BackDisplayComponent): string {
    if (!row) {
      return `${this.isAllSelected() ? 'select' : 'deselect'} all`;
    }
    return `${this.selection.isSelected(row) ? 'deselect' : 'select'} row ${row.position + 1}`;
  }
}
