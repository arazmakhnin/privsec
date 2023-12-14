import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-gdpr-message',
  templateUrl: './gdpr-message.component.html',
  styleUrls: ['./gdpr-message.component.css']
})
export class GdprMessageComponent implements OnInit {
  showMessage: boolean = true;

  ngOnInit(): void {
    const userAgreed = localStorage.getItem('userAgreedToCookies');
    if (userAgreed) {
      this.showMessage = false;
    }
  }

  handleAgree(): void {
    localStorage.setItem('userAgreedToCookies', 'true');
    this.showMessage = false;
  }

  handleDisagree(): void {
    this.showMessage = false;
  }
}
