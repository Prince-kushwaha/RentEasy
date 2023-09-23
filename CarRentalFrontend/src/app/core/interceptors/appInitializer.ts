import { Observable, catchError, of, tap } from "rxjs";
import { AuthService } from "../services/auth-service.service";

export function appInitialzer(authService: AuthService): () => Observable<any> {
    return function () {
        return authService.IsUserLoggedIn().pipe(tap((user: any) => {
            authService.isLoggedIn.next(true);
            authService.user.next(user);
        }), catchError(() => {
            authService.isLoggedIn.next(false);
            return of('')
        }));
    }
}

