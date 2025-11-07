import getCurrencySymbol from "@/lib/helpers/getCurrencySymbol";

type CurrencyProps = {
  code: string;
};

export default function Currency({ code }: CurrencyProps) {
  return (
    <div className='w-14 flex items-center gap-2 font-montserrat text-xs'>
      <span className="text-theme-crimson font-semibold">{getCurrencySymbol(code)}</span>
      <span>{code.toUpperCase()}</span>
    </div>
  );
}
