// import { Injectable } from '@angular/core';
// import { HttpClient } from '@angular/common/http';
// import { Observable } from 'rxjs';
// import { tap } from 'rxjs/operators'; 
// import { JwtService } from './jwt.service';

// @Injectable({
//   providedIn: 'root'
// })
// export class AuthService {
//   private apiUrl = 'https://8080-dfbbeddfccdbcfacbdcbaeadbebabcdebdca.premiumproject.examly.io';

//   constructor(private http: HttpClient, private jwtService: JwtService) { }

//   // Function to login user and save JWT token
//   login(username: string, password: string): Observable<any> {
//     return this.http.post<any>(`${this.apiUrl}/api/login`, { username, password }).pipe(
//       tap(response => {
//         if (response && response.token) {
//           this.jwtService.saveToken(response.token);
//         }
//       })
//     );
//   }

//   // Function to logout user and remove JWT token
//   logout(): void {
//     this.jwtService.destroyToken();
//   }

//   // Function to check if user is logged in
//   isLoggedIn(): boolean {
//     return this.jwtService.isLoggedIn();
//   }
//   isAdmin(): boolean {
//     const token = this.jwtService.getToken();
//     if (!token) {
//       return false; 
//     }
    
//     const tokenParts = token.split('.');
//     if (tokenParts.length !== 3) {
//       return false; 
//     }
    
//     const decodedPayload = JSON.parse(atob(tokenParts[1]));
//     return decodedPayload.name === 'admin'; // Update this line
//   }
  
// }
// auth.service.ts

import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { tap } from 'rxjs/operators'; 
import { JwtService } from './jwt.service';

@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private apiUrl = 'https://8080-dfbbeddfccdbcfacbdcbaeadbebabcdebdca.premiumproject.examly.io';

  constructor(private http: HttpClient, private jwtService: JwtService) { }

  // Function to login user and save JWT token
  login(username: string, password: string): Observable<any> {
    return this.http.post<any>(`${this.apiUrl}/api/login`, { username, password }).pipe(
      tap(response => {
        if (response && response.token) {
          this.jwtService.saveToken(response.token);
        }
      })
    );
  }

  // Function to logout user and remove JWT token
  logout(): void {
    this.jwtService.destroyToken();
  }

  // Function to check if user is logged in
  isLoggedIn(): boolean {
    return this.jwtService.isLoggedIn();
    // return true;
  }
  isAdmin(): boolean {
    const token = this.jwtService.getToken();
    if (!token) {
      return false; 
    }
    
    const tokenParts = token.split('.');
    if (tokenParts.length !== 3) {
      return false; 
    }
    
    const decodedPayload = JSON.parse(atob(tokenParts[1]));
    return decodedPayload.name === 'admin';
  }
  
}
