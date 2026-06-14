import type { ConversionResponse } from "./types/conversion-response";

export const ConversionLanguage = {
  English: "english",
  German: "german",
} as const;

export type ConversionLanguage =
  (typeof ConversionLanguage)[keyof typeof ConversionLanguage];

export async function ConvertNumber(
  numberStr: string,
  language: ConversionLanguage,
): Promise<string> {
  const urlBase = import.meta.env.VITE_API_BASE;
  const params = new URLSearchParams({
    number: numberStr,
    language: language,
  });
  try {
    const preResponse = await fetch(`${urlBase}/Convert?${params.toString()}`);

    if (!preResponse.ok) {
      return "Error fetching from api.";
    }

    const response: ConversionResponse = await preResponse.json();
    return response.convertedNumber;
  } catch (error) {
    console.log(`Could not reach api, details: ${error}`);
    return "Api is not reachable.";
  }
}
