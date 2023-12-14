import {Component, OnInit} from '@angular/core';
import {NewUserDialogComponent} from "../new-item-form/new-user-dialog.component";
import {MatDialog} from "@angular/material/dialog";
import {User} from "../common/user";
import {HttpClient} from "@angular/common/http";

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})

export class HomeComponent implements OnInit {
  constructor(private dialog: MatDialog,
              private http: HttpClient) {
  }

  ngOnInit(): void {
    this.obtainUsers();
  }

  obtainUsers() {
    this.http.get<User[]>('/users').subscribe(
      (result) => {
        this.users = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  users: User[] = [];
  selectedItem: User | null = null;

  selectItem(selectedItem: User): void {
    this.selectedItem = selectedItem;
  }

  createNewUser(): void {
    this.openNewUserDialog();
  }

  openNewUserDialog(): void {
    const dialogRef = this.dialog.open(NewUserDialogComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe((result: User | undefined) => {
      if (result) {
        this.users.push(result);
        this.saveUser(result);
      }
    });
  }

  private saveUser(user: User) {
    this.http.post<User>('/users', user).subscribe(
      (result) => {
        user.id = result.id;
      },
      (error) => {
        console.error(error);
      }
    );
  }
}
