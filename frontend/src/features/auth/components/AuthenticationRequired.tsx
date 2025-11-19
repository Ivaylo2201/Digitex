import { useAuth } from '@/features/auth/stores/useAuth';
import { Navigate } from 'react-router';

type AuthenticationRequiredProps = React.PropsWithChildren;

export function AuthenticationRequired({
  children,
}: AuthenticationRequiredProps) {
  const { isAuthenticated } = useAuth();

  return isAuthenticated ? children : <Navigate to='/auth/sign-in' replace />;
}
