import { Navigate } from 'react-router';
import { useAuthStore } from '../stores/useAuth';

type AuthenticationRequiredProps = React.PropsWithChildren;

export function AuthenticationRequired({
  children,
}: AuthenticationRequiredProps) {
  const isAuthenticated = useAuthStore((state) => state.isAuthenticated);

  return isAuthenticated ? children : <Navigate to='/auth/sign-in' replace />;
}
