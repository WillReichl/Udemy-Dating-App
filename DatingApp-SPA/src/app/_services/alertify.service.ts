import { Injectable } from '@angular/core';
declare let alertify: any; // basically just letting TSLint know about alertify

@Injectable({
  providedIn: 'root'
})
export class AlertifyService {
  constructor() {}

  // Add wrappers around the various AlertifyJS methods
  confirm(message: string, okCallBack: () => any) {
    alertify.confirm(message, function(e) {
      if (e) {
        okCallBack();
      } else {
      }
    });
  }

  success(message: string) {
    alertify.success(message);
  }

  error(message: string) {
    alertify.error(message);
  }

  warning(message: string) {
    alertify.warning(message);
  }

  message(message: string) {
    alertify.message(message);
  }
}
