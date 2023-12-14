import { Component, OnInit } from '@angular/core';
import { MatDialogRef } from '@angular/material/dialog';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { User } from "../common/user";

@Component({
  selector: 'app-new-item-form',
  templateUrl: './new-user-dialog.component.html',
  styleUrls: ['./new-user-dialog.component.css']
})
export class NewUserDialogComponent implements OnInit {
  newItemForm: FormGroup;

  constructor(
    public dialogRef: MatDialogRef<NewUserDialogComponent>,
    private fb: FormBuilder
  ) {
    this.newItemForm = this.fb.group({});
  }

  ngOnInit(): void {
    this.newItemForm = this.fb.group({
      login: ['', Validators.required],
      firstName: ['', Validators.required],
      lastName: ['', Validators.required]
    });
  }

  onSave(): void {
    this.newItemForm.markAllAsTouched();

    if (this.newItemForm?.valid) {
      const newItem: User = {
        id: '',
        login: this.newItemForm.get('login')?.value,
        firstName: this.newItemForm.get('firstName')?.value,
        lastName: this.newItemForm.get('lastName')?.value
      };

      this.dialogRef.close(newItem);
    }
  }

  onCancel(): void {
    this.dialogRef.close();
  }

  isFieldInvalid(fieldName: string): boolean {
    const control = this.newItemForm.get(fieldName)!;
    return control.invalid && (control.dirty || control.touched);
  }
}
