import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class JwtService {

  constructor() { }

  // Function to save JWT token to local storage
  saveToken(token: string): void {
    localStorage.setItem('jwtToken', token);
  }

  // Function to get JWT token from local storage
  getToken(): string | null {
    return localStorage.getItem('jwtToken');
  }

  // Function to remove JWT token from local storage
  removeToken(): void {
    localStorage.removeItem('jwtToken');
  }
}
