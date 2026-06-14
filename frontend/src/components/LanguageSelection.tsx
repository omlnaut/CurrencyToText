export type LanguageSelectionProps = { languages: string[] };

export function LanguageSelection({ languages }: LanguageSelectionProps) {
  return (
    <select id="languageSelect" className="language-select">
      {languages.map((k, i) => (
        <option key={i} value={k}>
          {k}
        </option>
      ))}
    </select>
  );
}
