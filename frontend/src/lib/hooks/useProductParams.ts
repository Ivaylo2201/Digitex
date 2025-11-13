import { useNavigate, useParams } from "react-router";

export const useProductParams = () => {
  const { category = '', id = '' } = useParams<{ category: string; id: string; }>();
  const navigate = useNavigate();

  if (category === undefined || id === undefined) {
    navigate('/404');
  }

  return { category, id };
};
