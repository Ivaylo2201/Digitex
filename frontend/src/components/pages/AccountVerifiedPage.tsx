import { useEffect } from "react";
import Page from "./Page";
import { http } from "@/lib/http";
import { useSearchParams } from "react-router";

export default function AccountVerifiedPage() {
  const [searchParams] = useSearchParams();

  useEffect(() => {
    const token = searchParams.get('token');

    if (token) {
      http.get(`/auth/verify?token=${encodeURIComponent(token)}`)
    }
  }, []);

  return <Page />;
}
