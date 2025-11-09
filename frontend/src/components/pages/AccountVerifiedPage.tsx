import { useEffect } from "react";
import Page from "./Page";
import { http } from "@/lib/http";
import { useSearchParams } from "react-router";

async function verifyAccount(token: string) {
  await http.get(`/auth/verify?token=${token}`)
}

export default function AccountVerifiedPage() {
  const [searchParams] = useSearchParams();

  useEffect(() => {
    const token = searchParams.get('token');

    if (token) {
      verifyAccount(token);
    }
  }, []);

  return <Page />;
}
