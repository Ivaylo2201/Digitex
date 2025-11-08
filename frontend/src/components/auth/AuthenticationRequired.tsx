import { useAuth } from "@/lib/stores/useAuth";
import { Navigate } from "react-router";

type AuthenticationRequiredProps = React.PropsWithChildren;

export default function AuthenticationRequired({ children }: AuthenticationRequiredProps) {
  const { isAuthenticated } = useAuth();

  return isAuthenticated ? children : <Navigate to='/auth/sign-in' replace />
};
